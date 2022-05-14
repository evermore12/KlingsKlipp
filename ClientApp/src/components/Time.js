import { useEffect, useState, useRef } from 'react';
import noUiSlider from 'nouislider'
import 'nouislider/dist/nouislider.css';
import '../css/Time.css'
import wNumb from 'wnumb'

export default function Time() {
    const slider = useRef();
    var formatter = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })
    useEffect(() => {
        var startTime = new Date(2022, 4, 12, 8).getTime()
        var endTime = new Date(2022, 4, 12, 12).getTime()
        noUiSlider.create(slider.current, {
            range: {
                min: startTime,
                max: endTime
            },
            start: [startTime],
            // Steps of 10 minutes
            step: 1000 * 60 * 10,
            format: {
                // 'to' the formatted value. Receives a number.
                to: function (value) {
                    return formatter.format(new Date(value))
                },
                // 'from' the formatted value.
                // Receives a string, should return a number.
                from: function (value) {
                    return 1
                }
            },
            tooltips: [true]
        });

slider.current.noUiSlider.on('update', (values, handle) => {
    document.getElementById('event-start').innerHTML = values[handle]
})
    }, [])
    return (<>
        <div className='slider-container'>
            <div ref={slider}></div>
            <p id='event-start'></p>
            <p id='event-end'></p>
        </div>
    </>)
}







        /*         noUiSlider.create(slider.current, {
                    start: [20, 20, 50, 50],
                    range: {
                        min: [0],
                        max: [100]
                    },
                    pips: 'range',
                    connect: [true, false, true, false, true],
                    behaviour: 'drag-all',
                })
        
        
                slider.current.getElementsByClassName('noUi-connect')[0].classList.add('disabled')
                slider.current.getElementsByClassName('noUi-connect')[2].classList.add('disabled')
         */
        // slider1.current.getElementsByClassName('noUi-connect')[3].classList.add('disabled')