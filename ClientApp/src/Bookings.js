import { useState } from "react"
import { Dropdown } from "react-bootstrap"
import { CustomMenu, CustomToggle } from "./CustomDropdownBookings"

export default function Bookings(){

    const [bookings, setBookings] = useState()
    function getBookings()
    {
        fetch("/booking").then(res => res.json()).then(json => setBookings(json))
    }
    return(
        <>
    <Dropdown>
      <Dropdown.Toggle id="dropdown-custom-components">
        Bookings
      </Dropdown.Toggle>
  
      <Dropdown.Menu as={CustomMenu}>
        <Dropdown.Item eventKey="1">Red</Dropdown.Item>
        <Dropdown.Item eventKey="2">Blue</Dropdown.Item>
        <Dropdown.Item eventKey="3" active>
          Orange
        </Dropdown.Item>
        <Dropdown.Item eventKey="1">Red-Orange</Dropdown.Item>
      </Dropdown.Menu>
    </Dropdown>,
        </>
    )
}