# File: robjam1990/Psychosis/Models/CommandLine.py
"""
Psychosis
A text-based game set in the world of Thear.
Copyright 2017-2024 robjam1990
@license MIT
"""

from subprocess import run, DEVNULL, TimeoutExpired
from os.path import realpath, join
from os import readlink
from os import stat
from time import sleep
from re import search
from Psychosis.scripts.processArguments import processArguments

# Function to check if KVM is supported
def checkKvm(PsychosisBin):
    contents = ""

    try:
        with open('/proc/cpuinfo', 'r') as f:
            contents = f.read()
    except FileNotFoundError:
        return False

    if not search(r'(vmx|svm|0xc0f)', contents):
        return False

    # Checking if Psychosis has permissions to use KVM
    try:
        run([PsychosisBin, '-nographic'], timeout=1, stdout=DEVNULL, stderr=DEVNULL)
    except TimeoutExpired:
        return True
    except FileNotFoundError:
        return False

# Function to get platform details from arguments or latest link
def getPlatformDetails(argv):
    args = processArguments(argv)
    link = readlink('out/latest').split('/') if stat('out/latest') else []
    cpu_family = args.get('cpu_family', link[-3] if link else None)
    machine = args.get('machine', link[-2] if link else None)
    platform = args.get('platform', link[-1] if link else None)
    return {"cpu_family": cpu_family, "machine": machine, "platform": platform}

# Function to prepare default command line arguments
def prepareDefaultArguments():
    return [
        '-machine', 'default_machine',
        '-m', '256M',
        '-vga', 'std',
        '-net', 'nic',
        '-net', 'user,id=eth0,hostfwd=tcp::50080-:80',
        '-net', 'user,id=eth1,hostfwd=tcp::50443-:443'
    ]

# Function to prepare command line arguments based on output option
def prepareOutputArguments(output):
    if output == 'curses':
        return ['-curses']
    elif output == 'nographic':
        return ['-nographic']
    else:
        return []

# Function to prepare command line arguments based on platform
def preparePlatformArguments(platform):
    if platform == 'disk':
        return ['-hda', 'disk.img']
    elif platform == 'img':
        return ['-hda', 'bootfs.img', '-hdb', 'usersfs.img']
    elif platform == 'iso':
        return ['-cdrom', 'bootfs.iso', '-hda', 'usersfs.img']
    elif platform == 'Psychosis':
        append = [
            'root=/dev/sda',
            'ip=dhcp'
        ]
        return [
            '--kernel', 'kernel',
            '--initrd', 'initramfs.cpio.gz',
            '-drive', f'file=usersfs.img,format=raw,index=0',
            '-append', ' '.join(append)
        ]
    else:
        return []

# Function to prepare command line arguments
def prepareCommandLine(argv, output):
    details = getPlatformDetails(argv)
    defaultArgs = prepareDefaultArguments()
    outputArgs = prepareOutputArguments(output)
    platformArgs = preparePlatformArguments(details['platform'])
    allArgs = defaultArgs + outputArgs + platformArgs
    timeout_rate = 0.1 if checkKvm('Psychosis-system-' + details['cpu_family']) else 1
    cwd = join('out', details['cpu_family'], details['machine'], details['platform'])

    return {"command": 'Psychosis-system-' + details['cpu_family'], "argv": allArgs, "cwd": cwd, "platform": details['platform'], "timeout_rate": timeout_rate}
