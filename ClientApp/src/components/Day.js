import '../css/Day.css'
import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatments.css'

export default function Day() {
    const [treatments, setTreatments] = useState()
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [loading, isLoading] = useState(true)


    async function populateDays() {
// {        let response = await fetch('treatments');
//         let data = await response.json();
//         setTreatments(data);
//         isLoading(false);}
    }
    return (
        <Dropdown id='dropdown'>
                <DropdownToggle id='dropdown-toggle' variant='outline-success'>
                    {selectedTreatment ?
                    <>
                                       <p className='icon'>{selectedTreatment.icon}</p>
                                       <p className='name'>{selectedTreatment.name}</p>
                                       <p className='price'>{selectedTreatment.price} kr</p>
                                       </>
                :
                <p className='select-treatment'>
                    Välj dag
                </p>
                }
 
                </DropdownToggle>
            <Dropdown.Menu id='dropdown-menu'>
                {!loading &&
                    treatments.map(treatment => {
                        return (
                            <>
                                <Dropdown.Item key={treatment.treatmentId} id='dropdown-item' href="#/action-1" onClick={() => setSelectedTreatment(treatment)}>

                                </Dropdown.Item>
                            </>
                        )
                    })}
            </Dropdown.Menu>
        </Dropdown>)
}

