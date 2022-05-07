import '../css/Time.css'
import noUiSlider from 'nouislider';
import { useEffect, useRef, useState } from 'react'
import 'nouislider/dist/nouislider.css';

export default function Day() {
    const slider1 = useRef()
    const slider2 = useRef()
    const [lockedValues, setLockedValues] = useState([60, 80]);



    useEffect(() => {
        noUiSlider.create(slider1.current, {
            start: [40, 60, 80, 100],
            behaviour: 'drag',
            margin: 10,
            limit: 30,
            connect: [false, true, false, true, false],
            range: {
                'min': 20,
                'max': 120
            },
        });

        noUiSlider.create(slider2.current, {
            start: 80,
            animate: false,
            range: {
                min: 50,
                max: 100
            }
        });

        slider1.current.noUiSlider.on('change', updateLockedValues);
        slider2.current.noUiSlider.on('change', updateLockedValues);

        slider1.current.noUiSlider.on('slide', function (values, handle) {
            crossUpdate(values[handle], slider2.current);
        });

        slider2.current.noUiSlider.on('slide', function (values, handle) {
            crossUpdate(values[handle], slider1.current);
        });
    }, [])

    function crossUpdate(value, slider) {



        // Select whether to increase or decrease
        // the other slider value.
        var a = slider1.current === slider ? 0 : 1;

        // Invert a
        var b = a ? 0 : 1;

        // Offset the slider value.
        value -= lockedValues[b] - lockedValues[a];

        // Set the value
        slider.noUiSlider.set(value);
    }

    function updateLockedValues() {
        setLockedValues([
            Number(slider1.current.noUiSlider.get()),
            Number(slider2.current.noUiSlider.get())
        ]);
    }
    return (<>
        <div className='slider-container'>
            <div ref={slider1}></div>
            <div ref={slider2}></div>
        </div>
        <section data-range-slider ng-model="range"></section>
    </>)
}