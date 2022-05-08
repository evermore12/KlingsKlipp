import '../css/Time.css'
import noUiSlider from 'nouislider';
import { useEffect, useRef } from 'react'
import 'nouislider/dist/nouislider.css';

export default function Day() {
    const slider1 = useRef()
    // const slider2 = useRef()
    // const [lockedValues, setLockedValues] = useState([60, 80]);



    useEffect(() => {
        noUiSlider.create(slider1.current, {
            start: [5, 25, 30, 50, 75, 100],
            connect:[false, true, false, true, false, true, false],
            behaviour: "drag",

            // Disable animation on value-setting,
            // so the sliders respond immediately.
            animate: false,
            range: {
                min: 0,
                max: 100
            },
            pips: {mode: 'count', values: 5}
            
        })
        var connect = document.querySelectorAll('.noUi-connect');
        var classes = ['c-1-color', 'c-2-color', 'c-3-color', 'c-4-color', 'c-5-color'];
        
        for (var i = 0; i < connect.length; i++) {
            connect[i].classList.add(classes[i]);
        }

        // noUiSlider.create(slider2.current, {
        //     start: 80,
        //     animate: false,
        //     range: {
        //         min: 50,
        //         max: 100
        //     }
        // });

        // slider1.current.noUiSlider.on('slide', function (values, handle) {
        //     crossUpdate(values[handle], slider2.current);
        // });

        // slider2.current.noUiSlider.on('slide', function (values, handle) {
        //     crossUpdate(values[handle], slider1.current);
        // });
    }, [])

    // function crossUpdate(value, slider) {

    //     // Select whether to increase or decrease
    //     // the other slider value.
    //     var a = slider1.current === slider ? 0 : 1;

    //     // Invert a
    //     var b = a ? 0 : 1;
    //     // Offset the slider value.
    //     value -= lockedValues[b] - lockedValues[a];

    //     // Set the value
    //     slider.noUiSlider.set(value);
    // }

    return (<>
        <div className='slider-container'>
            <div ref={slider1}></div>
            {/* <div ref={slider2}></div> */}
        </div>
        <section data-range-slider ng-model="range"></section>
    </>)
}