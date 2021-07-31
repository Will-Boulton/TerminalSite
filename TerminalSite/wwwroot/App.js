//Set the title of the page
setTitle = (title) => { document.title = title; };

//Get the dimensions of the window
getWindowDimensions = function () {
            return {
                width: window.innerWidth,
                height: window.innerHeight
            };
        }; 

//Get the bounding rectangle for an element
getBoundingClientRect = (element, parm) => { return element.getBoundingClientRect(); };


preventTab = function (componentReference, inputReference) {
    inputReference.onkeydown = function (event) {
        //Tab keycode is 9
        if (event.keyCode == "9") {
            event.preventDefault();
            componentReference.invokeMethodAsync("AutoComplete",inputReference.value);
        }
    };
}