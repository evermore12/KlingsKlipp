import '../css/Time.css'
import { Slider } from '@mui/material';

import 'rc-slider/assets/index.css';
import { useState } from 'react';

const minDistance = 10;
export default function Day() {
    const [value, setValue] = useState([10, 30])

    const handleChange = (event, newValue, activeThumb) => {
        if (!Array.isArray(newValue)) {
          return;
        }
    
        if (newValue[1] - newValue[0] < minDistance) {
          if (activeThumb === 0) {
            const clamped = Math.min(newValue[0], 100 - minDistance);
            setValue([clamped, clamped + minDistance]);
          } else {
            const clamped = Math.max(newValue[1], minDistance);
            setValue([clamped - minDistance, clamped]);
          }
        } else {
          setValue(newValue);
        }
      };
    return (<>
        <div className='slider-container'>
            <Slider track={false} disableSwap value={value} onChange={handleChange}/>
        </div>
    </>)
}