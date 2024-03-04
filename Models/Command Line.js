// File = robjam1990/Psychosis/Models/CommandLine.js
/**
 * Psychosis
 * A text-based game set in the world of Thear.
 * Copyright 2017-2024 robjam1990
 * @license MIT
 */

import { readFileSync, readlinkSync, statSync } from 'fs';
import { join } from 'path';
import { spawnSync } from 'child_process';
import processArguments from 'Psychosis/scripts/processArguments';

// Function to check if KVM is supported
function checkKvm(PsychosisBin) {
    let contents = "";

    try {
        contents = readFileSync('/proc/cpuinfo');
    } catch (e) {
        if (e.code !== 'ENOENT') throw e;
        return false;
    }

    if (!/(vmx|svm|0xc0f)/.test(contents)) return false;

    // Checking if Psychosis has permissions to use KVM
    try {
        spawnSync(PsychosisBin, ['-nographic'], { timeout: 1000 });
    } catch (e) {
        return true;
    }
}

// Function to get platform details from arguments or latest link
function getPlatformDetails(argv) {
    const args = processArguments(argv);
    const link = readlinkSync('out/latest').split('/') || [];
    return {
        cpu_family: args.cpu_family || link[link.length - 3],
        machine: args.machine || link[link.length - 2],
        platform: args.platform || link[link.length - 1]
    };
}

// Function to prepare default command line arguments
function prepareDefaultArguments() {
    return [
        '-machine', 'default_machine',
        '-m', '256M',
        '-vga', 'std',
        '-net', 'nic',
        '-net', 'user,id=eth0,hostfwd=tcp::50080-:80',
        '-net', 'user,id=eth1,hostfwd=tcp::50443-:443'
    ];
}

// Function to prepare command line arguments based on output option
function prepareOutputArguments(output) {
    switch (output) {
        case 'curses':
            return ['-curses'];
        case 'nographic':
            return ['-nographic'];
        default:
            return [];
    }
}

// Function to prepare command line arguments based on platform
function preparePlatformArguments(platform) {
    switch (platform) {
        case 'disk':
            return ['-hda', 'disk.img'];
        case 'img':
            return ['-hda', 'bootfs.img', '-hdb', 'usersfs.img'];
        case 'iso':
            return ['-cdrom', 'bootfs.iso', '-hda', 'usersfs.img'];
        case 'Psychosis':
            const append = [
                'root=/dev/sda',
                'ip=dhcp'
            ];
            return [
                '--kernel', 'kernel',
                '--initrd', 'initramfs.cpio.gz',
                '-drive', `file=usersfs.img,format=raw,index=0`,
                '-append', append.join(' ')
            ];
        default:
            return [];
    }
}

// Function to prepare command line arguments
function prepareCommandLine(argv, output) {
    const { cpu_family, machine, platform } = getPlatformDetails(argv);
    const defaultArgs = prepareDefaultArguments();
    const outputArgs = prepareOutputArguments(output);
    const platformArgs = preparePlatformArguments(platform);
    const allArgs = defaultArgs.concat(outputArgs, platformArgs);
    const timeout_rate = checkKvm('Psychosis-system-' + cpu_family) ? 0.1 : 1;
    const cwd = join('out', cpu_family, machine, platform);

    return { command: 'Psychosis-system-' + cpu_family, argv: allArgs, cwd, platform, timeout_rate };
}

export default prepareCommandLine;
