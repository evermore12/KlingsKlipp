import '../css/Day.css'

import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatments.css'
import Time from './Time'

export default function Day() {

    return (
        <Dropdown id='dropdown'>
                <DropdownToggle id='dropdown-toggle' variant='outline-success'>

                <p className='select-treatment'>
                    Välj dag
                </p>
                
 
                </DropdownToggle>
            <Dropdown.Menu id='dropdown-menu'>
                            
                                <Dropdown.Item id='dropdown-item' key='ello' href="#/action-1" >
                                <Time/>
                                </Dropdown.Item>
                                <Dropdown.Item id='dropdown-item' key='ello' href="#/action-1" >
                                <Time/>
                                </Dropdown.Item>
                            
                        
            </Dropdown.Menu>
        </Dropdown>)
}

