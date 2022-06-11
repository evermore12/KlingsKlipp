import { height } from '@mui/system';
import { forwardRef, useState, Children, useRef, useEffect } from 'react'
import { FormControl, ListGroup } from 'react-bootstrap';
import styles from '../css/CustomDropdown.module.css'
import React from 'react';
import noUiSlider from 'nouislider';
import 'nouislider/dist/nouislider.css';

const CustomMenu = forwardRef(
    ({ children, className, }, ref) => {
        const [showDropdown, setShopdropdown] = useState();
        const slider = useRef();

        return (
            <div
                ref={ref}
                className={className}
                style={{ width: "100%", padding: 0 }}
            >
                <ListGroup className="list-unstyled" variant='flush'>
                    {children}
                </ListGroup>
            </div>
        );
    },
);

const CustomItem = forwardRef(
    ({ hideDropdown, day, setSelectedDay }, ref) => {
        const slider = useRef();

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

        useEffect(() => {
                noUiSlider.create(slider.current, {
                    start: getStart(),
                    connect: getConnects(),
                    range: {
                        min: 1000 * 60 * 60 * 7,
                        max: 1000 * 60 * 60 * 20
                    },
                    behaviour: 'drag',
                    step: 1000 * 60 * 10,
                });
                slider.current.setAttribute('disabled', true);
                let handle = slider.current.querySelectorAll('.noUi-handle')
                handle.forEach(handle => handle.style.display = 'none')
        }, [])


        return (
            <>
                <ListGroup.Item action onClick={() => {hideDropdown(); setSelectedDay(day)}}>
                    <div className={styles.flexbox}>
                        <div className={styles.date}>
                            <p>{day.date}</p>
                        </div>
                        <div ref={slider} className={styles["noUiSlider-container"]}>
                        </div>
                    </div>
                </ListGroup.Item>
            </>
        );
    },
);

export { CustomItem, CustomMenu }