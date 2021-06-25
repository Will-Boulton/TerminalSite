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