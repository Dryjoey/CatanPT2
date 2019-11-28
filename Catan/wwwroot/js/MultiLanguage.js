var arrLang = {
    "en": {
        'Boardgenerator': 'Board Generator',
        'DarkMode': 'Dark Mode',
        'Generateboard': 'Generate Board',
        'Languages': 'Change Languages to Dutch',
        'Library': 'Library',
        'gSettings': 'Generator settings',
        'Random': 'Random',
        'Fixed': 'Fixed',
        'TilesAndChips': 'Tiles and Chips',
        'ChipPlacement': 'Chip Placement',
        'Player': 'Number of Players',
        'MainMenu': 'Main Menu',
        'GenSameSettings': 'Generate same settings',
        'GenNewSettings': 'Generate new settings',
        'SaveImage': 'Save as Image',
        'SaveLibrary': 'Save in Library',
        'Create': 'Create',
        'Menu': 'Menu',
        'Library': 'Library',
        'Test': 'Test',
        'Sheep': 'sheep',
        'Brick': 'brick',
        'Any': 'any',


    },
    "nl": {
        'Boardgenerator': 'Bord Generator',
        'DarkMode': 'Donker Modes',
        'Generateboard': 'Genereer Bord',
        'Languages': 'Verander Taal naar engels',
        'Library': 'Bibliotheek',
        'gSettings': 'Generator opties',
        'Random': 'Willekeurig',
        'Fixed': 'Statisch',
        'TilesAndChips': 'Tegels en Chips',
        'Player': 'Aantal spelers',
        'MainMenu': 'Hoofd menu',
        'GenSameSettings': 'Genereer met dezelfde opties',
        'GenNewSettings': 'Genereer met nieuwe opties',
        'SaveImage': 'Sla op als afbeelding',
        'SaveLibrary': 'Sla op in collectie',
        'Create': 'Creëer',
        'Menu': 'Menu',
        'Library': 'Collectie',
        'Test': 'Test',
        'Sheep': 'schaap',
        'Brick': 'baksteen',
        'Any' : 'elke',

    }
};
var lang = sessionStorage.getItem('lang');

$(function () {
    if (sessionStorage.getItem('lang') == null || undefined) {
        sessionStorage.setItem('lang', 'en');
    }
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function(index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
});

// Process translation
function Changelanguage(parameters) {
    if (sessionStorage.getItem('lang') === 'en') {
        sessionStorage.setItem('lang', 'nl');
    }
    else if (sessionStorage.getItem('lang') === 'nl') {
        sessionStorage.setItem('lang',  'en');
    }
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function (index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
}
