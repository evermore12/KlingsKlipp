import styles from '../css/Time.module.css'
import noUiSlider from 'nouislider';
import mergeTooltips from "../shared/MergeTooltips";
import 'nouislider/dist/nouislider.css'
import { useEffect, useRef, useState } from "react";

const BookTime = ({selectedTimeblock, selectedTreatment, setSelectedTime}) => {
    const slider = useRef()
    var formatterSlider = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })
    var formatter = new Intl.DateTimeFormat('en-US', {
        timeStyle: 'short'
    })

    useEffect(() => {
        noUiSlider.create(slider.current, {
            start: [selectedTimeblock.startUnix, selectedTimeblock.startUnix + selectedTreatment.durationUnix],
            connect: [false, true, false],
            range: {
                min: selectedTimeblock.startUnix,
                max: selectedTimeblock.endUnix
            },
            behaviour: 'drag-fixed',
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
        slider.current.noUiSlider.on("update", (values, handle) => {
            setSelectedTime(values)
        });
    }, [])

    
    return(
        <>
        <div ref={slider}></div>
        </>
    )
}
export {BookTime}