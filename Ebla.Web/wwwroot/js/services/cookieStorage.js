function set(obj) {
    document.cookie = `${obj.name}=${obj.value}`;
}

function get() {
    return document.cookie;
}

export { set, get };