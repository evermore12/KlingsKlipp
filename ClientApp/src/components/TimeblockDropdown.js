import styles from '../css/Time.module.css'
import noUiSlider from 'nouislider';
import mergeTooltips from "./MergeTooltips";
import 'nouislider/dist/nouislider.css'
import { useEffect, useRef, useState } from "react";


export default function SelectTimeblock({ day, setSelectedTimeblock }) {
    const slider = useRef();
    var formatterSlider = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })

    function disableHandles() {
        let handle = slider.current.querySelectorAll('.noUi-handle')
        handle.forEach(handle => handle.style.display = 'none')

        let base = slider.current.querySelectorAll('.noUi-base')
        base.forEach(base => base.style.cursor = 'default')


        let connect = slider.current.querySelectorAll('.noUi-connect')
        connect.forEach((connect, index) => {

            connect.addEventListener("click", (e) => {
                let id = Number.parseInt(e.currentTarget.id)
                let values = slider.current.noUiSlider.get()
                let start = values[id * 2]
                let end = values[id * 2 +1]

                let timeBlock = day.timeblocks.filter(value => 
                    value.start === start && value.end === end
                )
                
                setSelectedTimeblock(timeBlock[0])
            })
            connect.id = index
        });


    }

    function getConnects() {
        let array = new Array();
        if (day.timeblocks) {
            array = day.timeblocks.flatMap((timeblock) => {
                return [false, true]
            })
            array.push(false)
        }
        else {
            array = [false, false]
        }
        return array
    }
    function getStart() {

        let array = new Array();
        if (day.timeblocks) {
            array = day.timeblocks.flatMap((timeblock) => {
                return [timeblock.startUnix, timeblock.endUnix]
            })
        }
        else {
            array = [1]
        }
        return array
    }

    var formatter = new Intl.DateTimeFormat('en-US', {
        timeStyle: 'short'
    })

    useEffect(() => {
        if (slider.current.noUiSlider) {
            slider.current.noUiSlider.destroy()
        }

            noUiSlider.create(slider.current, {
                start: getStart(),
                connect: getConnects(),
                range: {
                    min: 1000 * 60 * 60 * 7,
                    max: 1000 * 60 * 60 * 20
                },
                behaviour: 'drag',
                format: {
                    to: function (value) {
                        return formatterSlider.format(new Date(value - 1000 * 60 * 60));
                    },
                    from: function (value) {
                        return value
                    }
                },
                step: 1000 * 60 * 10,
                pips:
                {
                    mode: 'positions',
                    values: [0, 25, 50, 75, 100],
                    density: 10,
                    format: {
                        to: function (value) {
                            return formatter.format(value - 1000 * 60 * 60)
                        },
                        from: function (value) {
                            return value
                        }
                    }
                },
            });
        

        slider.current.setAttribute('booking', true);
        slider.current.setAttribute('disabled', true);
        disableHandles()
    }, [day])
    return (<>
        <div className='mb-4' ref={slider} />
    </>)
}


// export default function SelectTime({day, treatment}) {
//     day.end = new Date(day.end).setHours(18)
//     var formatter = Intl.DateTimeFormat('sv-SE', {
//         timeStyle: 'short'
//     })
//     return (<>
//             <Nouislider
//                 range =
//                 {
//                     {
//                         min: day.start,
//                         max: day.end
//                     }
//                 }
//                 start =
//                 {
//                     [
//                         day.start,
//                         new Date(day.start).setHours(new Date(day.start).getHours() + 1)
//                     ]
//                 }
//                 behaviour = 'drag-all'
//                 connect =
//                 {
//                     [false, true, false]
//                 }
//                 step =
//                 {
//                     1000 * 60 * 10
//                 }
//                 pips =
//                 {
//                     {
//                         mode: 'positions',
//                         values: [0, 25, 50, 75, 100],
//                         density: 10,
//                         format: {
//                             to: function (value) {

//                                 return formatter.format(value)
//                                 // if(value === selectedDay.start || value === selectedDay.end)
//                                 // {
//                                 //     return formatter.format(value)
//                                 // }
//                                 // else
//                                 // {
//                                 //     return ""
//                                 // }
//                             },
//                             from: function (value) {
//                                 return value
//                             }
//                         }
//                     }
//                 }
//             />
//     </>)
// }
