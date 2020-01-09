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
        'two-one sheep': '2:1 sheep',
        'two-one brick': '2:1 brick',
        'three-one any': '3:1 any',
        'two-one ore': '2:1 ore',
        'two-one wood': '2:1 wood',
		'SaveLibText': 'Board Saved to Library!',


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
        'two-one sheep': '2:1 schaap',
        'two-one brick': '2:1 baksteen',
        'three-one any': '3:1 ieder',
        'two-one ore': '2:1 erts',
        'two-one wood': '2:1 hout',
		'SaveLibText': 'Board opgeslagen in collectie!',

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
        if (lang == 'en') {
            $(".submit-btn-en").css({ "visibility": "visible"});
        }
        else if (lang == 'nl') {
            $(".submit-btn-nl").css({ "visibility": "visible" });
        }
    })
});

// Process translation
function Changelanguage(parameters) {
    if (sessionStorage.getItem('lang') === 'en') {
        sessionStorage.setItem('lang', 'nl');
    }
    else if (sessionStorage.getItem('lang') === 'nl') {
        sessionStorage.setItem('lang', 'en');
    }
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function (index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
}