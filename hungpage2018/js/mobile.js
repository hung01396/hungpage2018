﻿window.onload = function () {
    var getNavi = document.getElementById('type-navigation-ul');

    var mobile = document.createElement("div");
    mobile.setAttribute("id", "mobile-navigation");
    getNavi.parentNode.insertBefore(mobile, getNavi);

    document.getElementById('mobile-navigation').onclick = function () {
        var a = getNavi.getAttribute('style');
        if (a) {
            getNavi.removeAttribute('style');
            document.getElementById('mobile-navigation').style.backgroundImage = 'url(./../../../../images/mobile/mobile-menu.png)';
        } else {
            getNavi.style.display = 'block';
            document.getElementById('mobile-navigation').style.backgroundImage = 'url(./../../../../images/mobile/mobile-close.png)';
        }
    };

    var getElm = getNavi.getElementsByTagName("li");
    for (var i = 0; i < getElm.length; i++) {
        if (getElm[i].children.length > 1) {
            var smenu = document.createElement("span");
            smenu.setAttribute("class", "mobile-submenu");
            smenu.setAttribute("OnClick", "submenu(" + i + ")");
            getElm[i].appendChild(smenu);
        };
    };

    submenu = function (i) {
        var sub = getElm[i].children[1];
        var b = sub.getAttribute('style');
        if (b) {
            sub.removeAttribute('style');
            getElm[i].lastChild.style.backgroundImage = 'url(../../../../../../images/mobile/mobile-collapse.png)';
        } else {
            sub.style.display = 'block';
            getElm[i].lastChild.style.backgroundImage = 'url(../../../../../../images/mobile/mobile-expand.png)';
        }
    };
};
