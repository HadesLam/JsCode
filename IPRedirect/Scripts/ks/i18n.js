var defaultLang = 'en';

function ready(fn) {
    if (document.readyState != 'loading') {
        fn();
    } else {
        document.addEventListener('DOMContentLoaded', fn);
    }
}

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
        case 'Janpanse':
            defaultLang = 'jp';
            break;
        default:
            defaultLang = 'en';
    }
    languageSelect(defaultLang);
})