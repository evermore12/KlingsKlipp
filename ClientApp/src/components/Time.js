import '../css/Time.css'
import noUiSlider from 'nouislider';
import { useEffect, useRef } from 'react'
import 'nouislider/dist/nouislider.css';

export default function Day() {
    const slider = useRef()
    useEffect(() => {
        noUiSlider.create(slider.current, {
            connect: true,
            behaviour: 'tap',
            start: [500, 4000],
            range: {
                // Starting at 500, step the value by 500,
                // until 4000 is reached. From there, step by 1000.
                'min': [0],
                '10%': [500, 500],
                '50%': [4000, 1000],
                'max': [10000]
            }
        });
    })
    return (<>
    <div className='slider-container'>
    <div ref={slider}></div>
    </div>
    <section data-range-slider ng-model="range"></section>
    </>)
}