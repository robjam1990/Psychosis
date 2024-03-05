'use strict';

// Importing required modules using ES6 import syntax
import { internalBinding } from 'internal/errors';
import os from 'os'; // Assuming 'os' module is available in your environment

const {
    getCPUs,
    getFreeMem,
    getHomeDirectory: _getHomeDirectory,
    getHostname: _getHostname,
    getLoadAvg,
    getOSRelease: _getOSRelease,
    getOSType: _getOSType,
    getTotalMem,
    getUptime,
} = internalBinding('os');

const avgValues = new Float64Array(3);

/**
 * Returns the load average values.
 * @returns {Array<number>} Array containing load average values.
 */
function loadavg() {
    getLoadAvg(avgValues);
    return [avgValues[0], avgValues[1], avgValues[2]];
}

/**
 * Returns CPU information.
 * @returns {Array<Object>} Array containing CPU information objects.
 */
function cpus() {
    const data = getCPUs() || [];
    const result = [];

    for (let i = 0; i < data.length; i += 7) {
        const cpuEntry = {
            model: data[i],
            speed: data[i + 1],
            times: {
                user: data[i + 2],
                nice: data[i + 3],
                sys: data[i + 4],
                idle: data[i + 5],
                irq: data[i + 6],
            },
        };
        result.push(cpuEntry);
    }
    return result;
}

/**
 * Returns the endianness of the processor.
 * @returns {string} The endianness of the processor.
 */
function endianness() {
    // Assuming 'os' module provides endianness information directly
    return os.endianness;
}

/**
 * Returns the home directory path of the current user.
 * @returns {string} The home directory path.
 */
function homedir() {
    return _getHomeDirectory();
}

/**
 * Returns the hostname of the operating system.
 * @returns {string} The hostname.
 */
function hostname() {
    return _getHostname();
}

/**
 * Returns the operating system release.
 * @returns {string} The operating system release.
 */
function release() {
    return _getOSRelease();
}

/**
 * Returns the type of the operating system.
 * @returns {string} The operating system type.
 */
function type() {
    return _getOSType();
}

/**
 * Returns the total memory of the system.
 * @returns {number} The total memory in bytes.
 */
function totalmem() {
    return getTotalMem();
}

/**
 * Returns the uptime of the system.
 * @returns {number} The uptime in seconds.
 */
function uptime() {
    return getUptime();
}

/**
 * Counts the number of ones in the binary representation of a number.
 * @param {number} n - The number to count ones in.
 * @returns {number} The count of ones in the binary representation.
 */
function countBinaryOnes(n) {
    let count = 0;
    while (n) {
        count += n & 1;
        n >>>= 1;
    }
    return count;
}

/**
 * Returns the platform of the operating system.
 * @returns {string} The platform.
 */
function platform() {
    return os.platform();
}

/**
 * Returns the temporary directory path.
 * @returns {string} The temporary directory path.
 */
function tmpdir() {
    return os.tmpdir();
}

// Use ES6 export syntax
export default {
    arch,
    cpus,
    endianness,
    freemem: getFreeMem,
    homedir,
    hostname,
    loadavg,
    platform,
    release,
    tmpdir,
    totalmem,
    type,
    uptime,
    countBinaryOnes,
};
