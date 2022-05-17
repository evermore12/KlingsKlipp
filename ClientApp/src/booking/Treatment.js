import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatment.css'


export default function Treatment({selectedTreatment, setSelectedTreatment}) {
    const [treatments, setTreatments] = useState()
    useEffect(() => {
        populateDropdown()
    }, [])

    function populateDropdown()
    {
        fetch('treatments')
            .then(res => res.json())
            .then(json => setTreatments(json.map(treatment => <Dropdown.Item value={treatment.name}>{treatment.name}</Dropdown.Item>)))
    }
    return (
        <Dropdown onSelect={(key, event) => setSelectedTreatment(event.currentTarget.innerHTML)}>
                <DropdownToggle variant='outline-success'>
                {!selectedTreatment ? 'Behandling' : selectedTreatment}
                </DropdownToggle>
            <Dropdown.Menu >
                {treatments}
            </Dropdown.Menu>
        </Dropdown>
    )
}