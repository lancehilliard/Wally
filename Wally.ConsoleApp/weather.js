(async function() {
    let [ adElement, forecastElement ] = await Wally_GetElements('#inner-content > div.city-body > div.row.current-forecast > div > div.row.city-forecast > div > div > city-today-forecast > div > div.small-12.medium-12.large-3.columns.alert-signup-wrap', '#inner-content > div.city-body > div.row.current-forecast > div > div.row.city-forecast > div');
    adElement.parentNode.removeChild(adElement);
    forecastElement.scrollIntoView(true);
})();