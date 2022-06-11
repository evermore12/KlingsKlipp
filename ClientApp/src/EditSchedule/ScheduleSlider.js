import noUiSlider from 'nouislider';
import mergeTooltips from "../shared/MergeTooltips";
import 'nouislider/dist/nouislider.css';
import { useEffect, useRef, useState } from "react";
import { Row, Col, Button } from 'react-bootstrap';
import styles from '../css/ScheduleSlider.module.css'
import UpdateMenu from './ActionsMenu';
import '../css/noUiSliderOverride.css'
const ScheduleSlider = ({ day, setUpdating, slider }) => {
        var formatterSlider = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })

    function updated(values, handle, unencoded, tap, positions, noUiSlider)
    {
        let blocks = day.timeblocks.flatMap(block => [block.startUnix, block.endUnix])
        let equal = (a, b) => JSON.stringify(blocks) === JSON.stringify(unencoded)
        if(!equal(blocks, unencoded))
            setUpdating(true)
        else
            setUpdating(false)
        
    }
    function getConnects() {
        let array = new Array();
        if(day.timeblocks)
        {
            array = day.timeblocks.flatMap((timeblock) => {
                return [false, true]
            })
            array.push(false)
        }
        else
        {
            array = [false, false]
        }
        return array
    }
    function getStart() {

        let array = new Array();
        if(day.timeblocks)
        {
            array =  day.timeblocks.flatMap((timeblock) => {
                return [timeblock.startUnix, timeblock.endUnix]
            })
        }
        else
        {
            array = [1]
        }
        return array
    }

    var formatter = new Intl.DateTimeFormat('en-US', {
        timeStyle: 'short'
    })

    useEffect(() => {
        if(slider.current.noUiSlider)
        {
            slider.current.noUiSlider.destroy()
        }
        if(day.timeblocks)
        {
            noUiSlider.create(slider.current, {
                start: getStart(),
                connect: getConnects(),
                tooltips: true,
                range: {
                    min: 1000 * 60 * 60 * 7,
                    max: 1000 * 60 * 60 * 20
                },
                behaviour: 'drag',
                format: {
                    to: function (value) {
                        return formatterSlider.format(new Date(value - 1000*60*60));
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
                            return formatter.format(value - 1000*60*60)
                        },
                        from: function (value) {
                            return value
                        }
                    }
                }
            });
            mergeTooltips(slider.current, 15, ' - ')
            slider.current.noUiSlider.on('set', updated)
        }
        else
        {
            noUiSlider.create(slider.current, {
                start: [0],
                connect: true,
                range: {
                    min: 1000 * 60 * 60 * 7,
                    max: 1000 * 60 * 60 * 20
                },
                behaviour: 'drag',
                step: 1000 * 60 * 10,
                pips:
                {
                    mode: 'positions',
                    values: [0, 25, 50, 75, 100],
                    density: 10,
                    format: {
                        to: function (value) {
                            return formatter.format(value - 1000*60*60)
                        },
                        from: function (value) {
                            return value
                        }
                    }
                }
            });
            let handle = slider.current.querySelectorAll('.noUi-handle')
            handle.forEach(handle => handle.style.display = 'none')
        }
    }, [day])
    return (<>
        <div className='mb-4' ref={slider} />
    </>)
}
export { ScheduleSlider }