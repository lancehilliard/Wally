(async function() {
    let now = new Date();
    let dayOfTheMonth = now.getDate();
    if (dayOfTheMonth >= 5) {
        let [ usageDivElement, graphDivElement ] = await Wally_GetElements('#usage > div > div:nth-child(1) > div > div > div > p > span > b:nth-child(1)', '#usage > div > div:nth-child(2) > div');
        let minutesInEveryDay = 60 * 24;
        let minuteOfTheMonth = ((dayOfTheMonth - 1) * minutesInEveryDay) + (now.getHours() * 60) + (now.getMinutes());
        let daysInCurrentMonth = new Date(now.getFullYear(), now.getMonth()+1, 0).getDate();
        let minutesInCurrentMonth = daysInCurrentMonth * minutesInEveryDay;
        let monthProgress = minuteOfTheMonth / minutesInCurrentMonth;
        let gigabytesRemaining = parseInt(usageDivElement.innerHTML.match(/\d/g).join(''));
        let quotaProgress = 1-gigabytesRemaining/1024;
        let displayProgress = Math.floor(quotaProgress / monthProgress * 100);
        let borderColor = displayProgress < 75 ? 'green' : (displayProgress < 95 ? 'yellow' : 'red');
        let n=document.createElement('div');
        n.style.position='absolute';
        n.style.right=0;
        n.style.marginRight='29px';
        n.style.border='4px solid ' + borderColor;
        n.style.top='34%';
        n.style.backgroundColor='lightblue';
        n.style.fontSize='96pt';
        n.style.lineHeight=1.0;
        n.style.fontWeight='bold';
        n.innerHTML=displayProgress;
        n.style.zIndex=1000;
        graphDivElement.prepend(n);
    }
    Wally_HideAllExcept('#usage');
    Wally_HideAll('.body4', '.chart__pagination', '.tooltip-modal', '.usage-courtesy--aside');
    document.querySelector('#usage').style.zoom = 1.25;
})();