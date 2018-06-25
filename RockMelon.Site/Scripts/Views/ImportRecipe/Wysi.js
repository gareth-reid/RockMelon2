function InitWysi() {
    //if whysihtml5 ever works in ie and you want to use it uncomment this and comment the tiny stuff below (also add resourceDir back as a paramenter)
    //$("#PageContent").wysihtml5({
    //    "color": true,
    //    "html": true,
    //    parserRules: wysihtml5ParserRules
    //});
    //$('#doc-dir').attr("value", resourceDir + "                  ");
    //$('#image-dir').attr("value", resourceDir + "                  ");

    //tiny stuff
        $('textarea.tinymce').tinymce({
            // Location of TinyMCE script
            script_url: '../../Scripts/Plugins/tiny_mce/tiny_mce.js',
            // General options
            theme: "advanced",
            plugins: "autolink,lists,pagebreak,table,iespell,insertdatetime,preview,searchreplace,paste,noneditable,visualchars,icode",

            // Theme options
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect,icode",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak",
            //theme_advanced_toolbar_location: "top",
           // theme_advanced_toolbar_align: "left",
           // theme_advanced_statusbar_location: "bottom",
           // theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "../Content/site.css"
        });
   //end tiny stuff
   
}


