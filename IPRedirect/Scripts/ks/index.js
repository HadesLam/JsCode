var defaultLang = 'en';

function ready(fn) {
    if (document.readyState != 'loading') {
        fn();
    } else {
        document.addEventListener('DOMContentLoaded', fn);
    }
}

/*µ÷ÓÃÓïÑÔ°ü*/
function languageSelect(defaultLang) {
    $("[i18n]").i18n({
        defaultLang: defaultLang,
        filePath: "../Scripts/i18n/",
        filePrefix: "i18n_",
        fileSuffix: "",
        forever: false
    });
}

ready(function () {
    var lang = (navigator.language || navigator.browserLanguage).toLowerCase();
    if (lang.indexOf('zh') >= 0) {
        if (lang.indexOf('cn') >= 0) {
            defaultLang = 'cn';
            $('.showLang').val('SimplifiedChinese');
        } else {
            defaultLang = 'hk';
            $('.showLang').val('TraditionalChinese');
        }
    }
    languageSelect(defaultLang)

    var drawing = SVG('watch-image');
    var watchCore = SVG.get('watch-core');
    var watchBand = SVG.get('watch-band');
    var watchCase = SVG.get('watch-case');
    var watchFace = SVG.get('watch-face');
    var watchBezel = SVG.get('watch-bezel');

    var speed = '0.5s';
    swatchCore = watchCore.attr('xlink:href');
    swatchBand = watchBand.attr('xlink:href');
    swatchCase = watchCase.attr('xlink:href');
    swatchFace = watchFace.attr('xlink:href');
    swatchBezel = watchBezel.attr('xlink:href');

    var _watchCore = document.querySelectorAll('.watchCore input[type="radio"]');
    count = _watchCore.length;
    for (var i = 0; i < count; i++) {
        _watchCore[i].addEventListener('change', function (e) {
            swatchCore = this.value;
            watchCore.animate(speed).attr('xlink:href', this.value);
        });
    }

    var _watchBand = document.querySelectorAll('.watchBand input[type="radio"]');
    count = _watchBand.length;
    for (var i = 0; i < count; i++) {
        _watchBand[i].addEventListener('change', function (e) {
            swatchBand = this.value;
            watchBand.animate(speed).attr('xlink:href', this.value);
        });
    }

    var _watchCase = document.querySelectorAll('.watchCase input[type="radio"]');
    count = _watchCase.length;
    for (var i = 0; i < count; i++) {
        _watchCase[i].addEventListener('change', function (e) {
            swatchCase = this.value;
            watchCase.animate(speed).attr('xlink:href', this.value);
        });
    }

    var _watchFace = document.querySelectorAll('.watchFace input[type="radio"]');
    count = _watchFace.length;
    for (var i = 0; i < count; i++) {
        _watchFace[i].addEventListener('change', function (e) {
            swatchFace = this.value;
            watchFace.animate(speed).attr('xlink:href', this.value);
        });
    }

    var _watchBezel = document.querySelectorAll('.watchBezel input[type="radio"]');
    count = _watchBezel.length;
    for (var i = 0; i < count; i++) {
        _watchBezel[i].addEventListener('change', function (e) {
            swatchBezel = this.value;
            watchBezel.animate(speed).attr('xlink:href', this.value);
        });
    }
});

document.getElementById('button-submit').addEventListener('click', function (e) {
    var swatch = 'IN' + swatchCore + swatchCase + swatchFace + swatchBezel + swatchBand;
    swatch = swatch.replace(/Images/g, '').replace(/product/g, '').replace(/\//g, '').replace(/.png/g, '');
    jQuery.get("/ks/add?model=" + swatch, function (result) { });
    layer.alert(swatch, {
        title: 'MODEL CODE',
        icon: 6,
        btn: ['CONFIRM']
    });
});

layui.use(['element', 'layer'], function () {
    element = layui.element;
    layer = layui.layer;
});

$('.showLang').change(function () {
    var condition = $(this).val();
    switch (condition) {
        case 'SimplifiedChinese':
            defaultLang = 'cn';
            break;
        case 'TraditionalChinese':
            defaultLang = 'hk';
            break;
        default:
            defaultLang = 'en';
    }
    languageSelect(defaultLang);
})