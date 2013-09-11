(function(){

    $(function() {
        $('a:not([href*="' + document.domain + '"])').click(function(event) {
            // event.preventDefault();

            var dest = this.href;

            /* 
            Of our many bad options here, firing a synchronous javascript is the least bad:
                - a setTimeout potentially locks up the DOM excessively
                - a delayed callback (with window.open) doesn't respect users choice to open in new tab, etc.
            */
            $.ajax({
                type: "GET",
                data: {"click": dest},
                url: "/track.gif",
                async: false // make the navigation wait until we've sent our tracking pixel
            })
        });
    })

    var getQueryParam = function(name) {
        var results, expression = "[\\?&]"+name+"=([^&#]*)";
        if (results = window.location.href.match(expression)) {
            return results[1];
        }
        return false;
    }

    var uri = "", utm_medium, q, params = {rand : Math.random()};

    if (document.location)
        params.location = document.location;
    if (document.referrer)
        params.referer = document.referrer;
    if (utm_medium = getQueryParam('utm_medium'))
        params.utm_medium = utm_medium;
    if ((typeof vertical != "undefined") && vertical)
        params.vertical = vertical;
    if (q = getQueryParam('q'))
        params.q = q;

	if (window.post && post) {
	    params.post_id = post.id || '';
	    params.post_author = (post.author instanceof Array) ? post.author.join('|') : post.author || '';
	    params.post_author_ids = post.author_ids || '';
	    params.post_type = post.post_type || '';
    }

	if (typeof _bi_domain != "undefined") {
		uri = document.location.protocol + "//" + _bi_domain;
	}

	uri += '/track.gif?';

    for (var k in params) {
        uri += '&' + k + '=' + encodeURIComponent(params[k]);
    }

	var i = new Image(1, 1);
		i.src = uri;
}());
