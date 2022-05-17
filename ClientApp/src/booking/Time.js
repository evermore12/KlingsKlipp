import { useEffect, useState, useRef } from 'react';
import noUiSlider from 'nouislider'
import 'nouislider/dist/nouislider.css';
import '../css/Time.css'
import wNumb from 'wnumb'
import Nouislider from "nouislider-react";
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'


export default function Time({treatment}) {
    const slider = useRef();
    var formatter = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })
    var formatterParts = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    }).formatToParts();
    var day = {
        start: new Date(2022, 4, 12, 8).getTime(),
        end: new Date(2022, 4, 12, 12).getTime()
    }

    
    useEffect(() => {
        console.log(treatment)
        var treatmentStart = new Date(2022, 4, 12, 9).getTime()
        var treatmentEnd = new Date(2022, 4, 12, 10).getTime()

        var availableTimeBefore = treatmentStart - (1000 * 60 * 10);
        var availableTimeAfter = treatmentEnd + (1000 * 60 * 10);
        // console.log(new Date(startTime))
        //     console.log(new Date(availableTimeBefore))
        //     console.log(new Date(treatmentStart))
        //     console.log(new Date(treatmentEnd))
        //     console.log(new Date(availableTimeAfter))
        // console.log(new Date(endTime))

        function filterPips(value, type) {
            let date = new Date(value)
            let minutes = date.getMinutes()
            switch (minutes) {
                case 0:
                    return 1;
                case 30:
                    return 2;
                default:
                    return 0
            }

        }
        // noUiSlider.create(slider.current, {
        //     range: {
        //         min: startTime,
        //         max: endTime
        //     },
        //     start: [treatmentStart, treatmentEnd],
        //     behaviour: 'drag-all',
        //     connect: [true, true, true],
        //     step: 1000 * 60 * 10,
        //     format: {
        //         to: function (value) {
        //             let date = new Date(value)
        //             return formatter.format(date)
        //         },
        //         from: function (value) {
        //             return value
        //         }
        //     },
        //     pips: {
        //         mode: 'steps',
        //         density: 5,
        //         filter: filterPips,
        //         format: {
        //             to: function (value) {
        //                 let date = new Date(value)
        //                 let formated = formatter.formatToParts(date);
        //                 if(formated[2].value === '00')
        //                     return formatter.format(date)
        //                 else
        //                     return formated[2].value
        //             },
        //             from: function (value) {
        //                 return value
        //             }
        //         }
        //     }
        // });

    }, [formatter])
    return (<>
    <Nouislider
        start={[day.start, day.end]}
        range={{min: day.start,
                max: day.start + treatment.duration}}
        
    />
    <div ref={slider}></div>
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