"use strict";

(function (ns) {

    function hidePostedData(checkbox) {
        const table = $(checkbox)
            .closest("div[data-day]")
            .find("table[id^='table-for']");

        $(table)
            .data("show-posted", "false")
            .find(" tr[data-posted]")
            .remove();
    }

    function fetchUnpostedAndPostedData(checkbox) {
        const container = $(checkbox).closest("div[data-day]");
        const url = $(container).data("url");
        $.get(url,
            function(partial) {
                $(container).html(partial);
            });
    }

    function toggle(checkbox) {
        if ($(checkbox).prop("checked")) {
            hidePostedData(checkbox);
        } else {
            fetchUnpostedAndPostedData(checkbox);
        }
    }

    function saveAndDelete(button) {
        $(button)
            .closest("tr")
            .remove();
    }

    function saveAndDisplay(button) {
        $(button)
            .closest("tr")
            .addClass("text-primary")
            .attr("data-posted", "");
        $(button)
            .remove();
    }

    function save(button) {
        const savePosted = $(button)
            .closest("div[data-day]")
            .find("table[id^='table-for']")
            .data("show-posted");

        if (savePosted === "false") {
            saveAndDelete(button);
        } else {
            saveAndDisplay(button);
        }
    }

    ns.toggle = toggle;
    ns.save = save;

})(window.Post = window.Post || {});

$(document).ready(function() {

    $("body")
        .on("change", "input:checkbox",
            function() {
                Post.toggle(this);
            }
        )
        .on("click", "button[data-save-button]",
            function() {
                Post.save(this);
            }
        );
})