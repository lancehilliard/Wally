(async function() {
    let now = new Date();
    let dayOfTheMonth = now.getDate();
    console.log('dayOfTheMonth: ' + dayOfTheMonth);
    if (dayOfTheMonth >= 5) {
        let [ usageDivElement, graphDivElement ] = await Wally_GetElements('#usage > div > div:nth-child(1) > div > div > div > p > span > b:nth-child(1)', '#usage > div > div:nth-child(2) > div');
        console.log('elements found');
        let daysInCurrentMonth = new Date(now.getFullYear(), now.getMonth()+1, 0).getDate();
        let monthProgress = dayOfTheMonth / daysInCurrentMonth;
        let gigabytesRemaining = parseInt(usageDivElement.innerHTML.match(/\d/g).join(''));
        let quotaProgress = 1-gigabytesRemaining/1024;
        let warningProgress = monthProgress * .91;
        let n=document.createElement('div');
        n.style.position='absolute';
        n.style.right=0;
        n.style.marginRight='29px';
        n.style.border='4px solid red';
        n.style.top='34%';
        n.style.backgroundColor='lightblue';
        n.style.fontSize='96pt';
        n.style.lineHeight=1.0;
        n.style.fontWeight='bold';
        n.innerHTML=Math.floor(quotaProgress / warningProgress * 100);
        n.style.zIndex=1000;
        graphDivElement.prepend(n);
    }
    Wally_HideAllExcept('#usage');
    Wally_HideAll('.body4', '.chart__pagination', '.tooltip-modal', '.usage-courtesy--aside');

    setInterval(function() {
        let continueSessionButton = document.querySelector('#ngdialog2 > div.ngdialog-content > div:nth-child(1) > div > div:nth-child(1) > button');
        if (continueSessionButton) {
            continueSessionButton.click();
        }
        let noSurveyButton = document.querySelector('#no');
        if (noSurveyButton) {
            noSurveyButton.click();
        }
    }, 250);
})();