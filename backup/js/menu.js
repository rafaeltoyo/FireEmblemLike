/**
 * 
 */

const initializeMenu = () => {
    let header = document.getElementsByTagName('header');
    if (header.length <= 0) {
        return null;
    }
    return createMenu(header[0]);
};

const createMenu = header => {
    let component = {};

    // Creating html elements
    let cmpNav = document.createElement('nav');
    header.appendChild(cmpNav);

    return component;
};
