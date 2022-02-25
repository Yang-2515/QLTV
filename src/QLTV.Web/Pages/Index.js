document.querySelector('.fa-home').nextElementSibling.style.color = 'var(--blue-color)' // css

$(function () {
    abp.log.debug('Index.js initialized!');

    //var input = {
    //    'keyword': "Đã trả",
    //    'SkipCount': 0,
    //    'MaxResultCount': 10
    //}
    
});
var ColorForCategory_RGB = {
    "Giáo trình": "#e6194b",
    "Tiểu thuyết": "#f58231",
    "Tâm lý": "#ffe119",
    "Tự lực": "#bfef45",
    "Văn học": "#3cb44b",
    "Chính trị": "#42d4f4",
    "Khoa học": "#4363d8",
    "Xã hội học": "#911eb4",
    "Y học": "#f032e6"
}

var ColorForCategory_RGBA = {
    "Giáo trình": "rgba(230, 0, 57, 0.6)",
    "Tiểu thuyết": "rgba(255, 112, 10, 0.6)",
    "Tâm lý": "rgba(255, 218, 0, 0.6)",
    "Tự lực": "rgba(189, 255, 22, 0.6)",
    "Văn học": "rgba(27, 189, 49, 0.6)",
    "Chính trị": "rgba(66, 212, 244, 0.6)",
    "Khoa học": "rgba(2, 56, 252, 0.6)",
    "Xã hội học": "rgba(145, 0, 189, 0.6)",
    "Y học": "rgba(255, 6, 243, 0.6)"
}

//======================================= SHOW SLIDE ===================================
var CurrentSlide = 0;
var slides = document.getElementsByClassName("slide");

function AutoShowSlides() {
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none"
    }
    if (CurrentSlide == slides.length)
        CurrentSlide = 0
    slides[CurrentSlide++].style.display = "block";
    setTimeout(AutoShowSlides, 4000)
}

function ClickShowSlide(n) {
    if (n > slides.length) { CurrentSlide = 1 }
    if (n < 1) { CurrentSlide = slides.length }

    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    slides[CurrentSlide - 1].style.display = "block";
}

function plusSlides(n) {
    ClickShowSlide(CurrentSlide += n);
}

AutoShowSlides()

var ExtentionElements = document.querySelectorAll(".extention")
for (var i = 0; i < ExtentionElements.length; i++) {
    ExtentionElements[i].addEventListener('click', function (e) {
        var IconDownElement = e.target.querySelector('.icon-down')
        if (IconDownElement) {
            IconDownElement.classList.toggle('active');
            e.target.nextElementSibling.classList.toggle('hiden')

        }
    })
}



