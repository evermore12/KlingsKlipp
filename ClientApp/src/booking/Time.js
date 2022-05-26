import '../css/Time.css'

import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'



export default function Time({day, treatment}) {
    day.end = new Date(day.end).setHours(18)
    var formatter = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })
    return (<>
            <Nouislider
                range = 
                {
                    {
                        min: day.start,
                        max: day.end
                    }
                }
                start = 
                {
                    [
                        day.start, 
                        new Date(day.start).setHours(new Date(day.start).getHours() + 1)
                    ]
                }
                behaviour = 'drag-all'
                connect = 
                {
                    [false, true, false]
                }
                step =  
                {
                    1000 * 60 * 10
                }
                pips = 
                {
                    {
                        mode: 'positions',
                        values: [0, 25, 50, 75, 100],
                        density: 10,
                        format: {
                            to: function (value) {

                                return formatter.format(value) 
                                // if(value === selectedDay.start || value === selectedDay.end)
                                // {
                                //     return formatter.format(value)
                                // }
                                // else
                                // {
                                //     return ""
                                // }
                            },
                            from: function (value) {
                                return value
                            }
                        }
                    }
                }
            />
    </>)
}