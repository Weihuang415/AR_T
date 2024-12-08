mergeInto(LibraryManager.library, {
    SimulateTouchEvent: function () {
        // Create a touch event
        var touchEvent = new TouchEvent('touchstart', {
            bubbles: true,
            cancelable: true,
            touches: [
                new Touch({
                    identifier: 0,
                    target: document.body,
                    clientX: window.innerWidth / 2, // Center of the screen
                    clientY: window.innerHeight / 2,
                    radiusX: 1,
                    radiusY: 1,
                    rotationAngle: 0,
                    force: 1,
                }),
            ],
        });

        // Dispatch the touch event on the canvas
        var canvas = document.querySelector('canvas');
        if (canvas) {
            canvas.dispatchEvent(touchEvent);
            console.log("Simulated touch event dispatched");
        } else {
            console.error("Canvas not found!");
        }
    }
});
