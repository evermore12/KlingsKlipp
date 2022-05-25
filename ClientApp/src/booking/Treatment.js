import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatment.css'


export default function Treatment({treatment, setTreatment}) {
    const [availableTreatments, setAvailableTreatments] = useState()
    useEffect(() => {
        populateDropdown()
    }, [])
    function populateDropdown()
    {
        fetch('treatments')
            .then(res => res.json())
            .then(json => setAvailableTreatments(json))
    }
    return (
        <Dropdown onSelect={(key) => setTreatment(availableTreatments[key])}>
                <DropdownToggle variant='outline-success'>
                {!treatment ? 'Behandling' : treatment.name}
                </DropdownToggle>
            <Dropdown.Menu >
            {availableTreatments && availableTreatments.map((treatment, index) => <Dropdown.Item key={index} eventKey={index}>{treatment.name}</Dropdown.Item>)}
            </Dropdown.Menu>
        </Dropdown>
    )
}