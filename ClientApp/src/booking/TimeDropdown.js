import { useEffect, useState, useRef } from 'react';
import noUiSlider from 'nouislider'
import 'nouislider/dist/nouislider.css';
import '../css/TimeDropdown.css'

export default function TimeDropdown({startTime, endTime}) {
    const slider = useRef();
    
    useEffect(() => {
        noUiSlider.create(slider.current, {
            range: {
                min: startTime,
                max: endTime
            },
            start: [startTime, endTime],
            behaviour: 'drag-all',
            connect: [true, true, true],
        });
        slider.current.getElementsByClassName('noUi-connect')[0].classList.add('disabled')
        slider.current.getElementsByClassName('noUi-connect')[2].classList.add('disabled')
    })
    return (<>
    <div className='slider-container'>
    <div ref={slider} id="slider"></div>
    </div>
    </>)
}