function Wally_Sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms)); // https://stackoverflow.com/a/39914235/116895
}

async function Wally_GetElements() {
    let selectors = arguments;
    let result = [];
    while (result.length !== selectors.length) {
        await Wally_Sleep(250);
        let foundElements = [];
        Wally_DoForArray(selectors, function(selector) {
            let element = document.querySelector(selector);
            let nullFound = element === null;
            if (!nullFound) {
                foundElements.push(element);
            }
            return nullFound;
        });
        result = foundElements;
    }
    return result;
}

function Wally_DoForArray(array, action) {
    for (let i=0; i < array.length; i++) {
        if (action(array[i], i)) {
            break;
        }
    }
}

function Wally_HideAllExcept() {
    let selectors = arguments;
    let nodes = document.querySelector('body').getElementsByTagName("*");
    Wally_DoForArray(nodes, function(node) {
        let shouldHide = true;
        Wally_DoForArray(selectors, function(selector) {
            let shouldStayVisible = node.querySelector(selector) !== null || node.matches(selector) || node.closest(selector) !== null;
            shouldHide = !shouldStayVisible;
            return shouldStayVisible;
        });
        if (shouldHide) {
            node.style.display = 'none';
        }
    });
}

function Wally_HideAll() {
    let selectors = arguments;
    Wally_DoForArray(selectors, function(selector) {
        Wally_DoForArray(document.querySelectorAll(selector), function(node) {
            node.style.display = 'none';
        });
    });
}