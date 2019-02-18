(async function() {
    await Wally_GetElements('#feed-tabs');
    Wally_HideAllExcept('#feed-tabs');
    Wally_HideAll('.block__more');
})();