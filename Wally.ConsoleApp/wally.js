function Wally_Sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms)); // https://stackoverflow.com/a/39914235/116895
}

async function Wally_GetElements() {
    let result = [];
    let nullFound = true;
    while (nullFound) {
        console.log('waiting');
        await Wally_Sleep(250);
        result = [];
        nullFound = false;
        for (let i = 0; i < arguments.length; i++) {
            let element = document.querySelector(arguments[i]);
            if (element !== null) {
                result.push(element);
            } else {
                nullFound = true;
                break;
            }
        }
    }
    return result;
}

