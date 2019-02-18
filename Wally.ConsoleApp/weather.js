(async function() {
    await Wally_GetElements('#feed-tabs');
    Wally_HideAllExcept('#feed-tabs');
    Wally_HideAll('.block__more');
    document.querySelector('#feed-tabs').style.zoom = 2;
    document.querySelector('#feed-tabs > ul > li.current > h3 > a').innerHTML = 'NOW';
})();