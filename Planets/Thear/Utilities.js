// Function to export utilities to other scripts
function Export(f) {
    f(exports_container);
}

// Function to import utilities from other scripts
function Import(f) {
    f.next = Import;
    Import = f;
}

// Function to import utilities immediately
function ImportNow(name) {
    return exports_container[name];
}

// Function to install constants
function InstallConstants(object, constants) {
    for (var i = 0; i < constants.length; i += 2) {
        var name = constants[i];
        var k = constants[i + 1];
        object[name] = k;
    }
}

// Function to set up locked prototype
function SetUpLockedPrototype(constructor, fields, methods) {
    var prototype = constructor.prototype;
    if (fields) {
        for (var i = 0; i < fields.length; i++) {
            prototype[fields[i]] = undefined;
        }
    }
    for (var i = 0; i < methods.length; i += 2) {
        var key = methods[i];
        var f = methods[i + 1];
        if (typeof f === 'function') {
            prototype[key] = f;
        }
    }
}

// Function to log stack trace
function logStackTrace() {
    console.trace();
}

// Function to log messages
function log() {
    console.log(...arguments);
}

// Function to create private symbol
function createPrivateSymbol(name) {
    return Symbol(name);
}
