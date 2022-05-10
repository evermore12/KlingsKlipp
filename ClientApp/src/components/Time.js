import { useEffect, useState, useRef } from 'react';
import NoUiSlider from 'nouislider'
import 'nouislider/dist/nouislider.css';
import '../css/Time.css'

var distance = 20;
export default function Time() {
    const slider1 = useRef();
    useEffect(() => {
        NoUiSlider.create(slider1.current, {
            start:[20,40, 60, 80],
            range:{
                min:[0],
                max:[100]
            },
            behaviour: 'drag-all',
            connect: [false, true, false, true, false]
        })
        
    
        
        var origins = slider1.current.getElementsByClassName('noUi-origin');
        var connect = slider1.current.getElementsByClassName('noUi-connect'); 
        connect[1].setAttribute('disabled', true);
        origins[1].setAttribute('disabled', true);
    }, [])
    return (<>
        <div className='slider-container'>
            <div ref={slider1}></div>
        </div>
    </>)
}