(function(global, undefined){
    var textBox = null;
 
    function textBoxLoad(sender) {
        textBox = sender;
    }
 
    function OpenFileExplorerDialog() {
        global.radopen("Explorer.aspx", "ExplorerWindow");
    }
 
    //This function is called from a code declared on the Explorer.aspx page
    function OnFileSelected(fileSelected) {
        if(textBox){
            textBox.set_value(fileSelected);
        }
    }
 
    global.OpenFileExplorerDialog = OpenFileExplorerDialog;
    global.OnFileSelected = OnFileSelected;
    global.textBoxLoad = textBoxLoad;
})(window);
(function(global, undefined){
    var textBox = null;
 
    function textBoxLoad(sender) {
        textBox = sender;
    }
 
    function OpenFileExplorerDialog() {
        global.radopen("Explorer.aspx", "ExplorerWindow");
    }
 
    //This function is called from a code declared on the Explorer.aspx page
    function OnFileSelected(fileSelected) {
        if(textBox){
            textBox.set_value(fileSelected);
        }
    }
 
    global.OpenFileExplorerDialog = OpenFileExplorerDialog;
    global.OnFileSelected = OnFileSelected;
    global.textBoxLoad = textBoxLoad;
})(window);