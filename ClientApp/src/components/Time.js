import { useEffect, useState, useRef } from 'react';
import NoUiSlider from 'nouislider'
import 'nouislider/dist/nouislider.css';
import '../css/Time.css'


var previousSlider;
export default function Time() {
    const slider1 = useRef();
    useEffect(() => {
        NoUiSlider.create(slider1.current, {
            start: [20, 40, 60, 80],
            range: {
                min: [0],
                max: [100]
            },
            connect: [false, true, false, true, false]
        })
        slider1.current.noUiSlider.on('drag', (values, handle) => {
            console.log(handle)
        })
                slider1.current.getElementsByClassName('noUi-connect')[1].classList.add('disabled')
                // slider1.current.getElementsByClassName('noUi-handle')[0].classList.add('disabled-origin')
        slider1.current.getElementsByClassName('noUi-touch-area')[0].classList.add('disabled-origin')

    }, [])
    return (<>
        <div className='slider-container'>
            <div ref={slider1}></div>
        </div>
    </>)
}