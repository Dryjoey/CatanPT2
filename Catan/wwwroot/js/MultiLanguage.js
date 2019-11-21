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
        'TilePlacement': 'Tile Placement',
        'ChipPlacement': 'Chip Placement',
        'Player': 'Number of Players',
        'MainMenu': 'Main Menu',
        'GenSameSettings': 'Generate same settings',
        'GenNewSettings': 'Generate new settings',
        'SaveImage': 'Save as Image',
        'SaveLibrary': 'Save in Library',


    },
    "nl": {
        'Boardgenerator': 'Bord Generator',
        'DarkMode': 'Donkere Modes',
        'Generateboard': 'Genereer Bord',
        'Languages': 'Verander Taal naar engels',
        'Library': 'Bibliotheek',
        'gSettings': 'Generator opties',
        'Random': 'Willekeurig',
        'Fixed': 'Statisch',
        'TilePlacement': 'Velden positie',
        'ChipPlacement': 'Fiche positie',
        'Player': 'Aantal spelers',
        'MainMenu': 'Hoofd menu',
        'GenSameSettings': 'Genereer met dezelfde opties',
        'GenNewSettings': 'Genereer met nieuwe opties',
        'SaveImage': 'Sla op als afbeelding',
        'SaveLibrary': 'Sla op in collectie'

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
