import { useState, useRef, useCallback, useEffect, Children } from "react"
import { Row, Col, Button } from "react-bootstrap"
import React from "react"
import styles from '../css/Flipcard.module.css'
const Flipcard = ({ front, back, children }) => {

    const card = useRef()
    const [rotation, setRotation] = useState(0)
    const [hidden, setHidden] = useState([false, false])

    const flip = () => {
        setHidden([false, false])
        if (rotation === 0) {
            setRotation(540)
        }
        else {
            setRotation(0)
        }
    }
    const flipFinish = useCallback(() => {
        if (rotation === 0) {
            setHidden([false, true])
        }
        else {
            setHidden([true, false])
        }
    })
    useEffect(() => {
        card.current.addEventListener('transitionend', flipFinish)
        return () => card.current.removeEventListener('transitionend', flipFinish)
    }, [flipFinish])
    return (
        <>
            <div ref={card} className={styles["flip-card"]}>
                <div className={styles["flip-card-inner"]} style={{ transform: `rotateY(${rotation}deg)` }}>
                    {React.cloneElement(children[0] )}
                    {React.cloneElement(children[1])}
                </div>
            </div>

            <Row className="justify-content-center pt-5 mt-5">
                <Col xs="auto">
                    <Button variant='outline-success' onClick={flip}>{rotation === 0 ? <i className="arrow right" /> : <i className="arrow left" />}</Button>
                </Col>
            </Row>
        </>
    )
}
const Front = ({ children, hidden }) => {
    return (
        <div className={styles["flip-card-front"]} hidden={hidden}>
            {children}
        </div>
    )
}
const Back = ({ children, hidden }) => {
    return (
        <div className={styles["flip-card-back"]} hidden={hidden}>
            {children}
        </div>
    )
}



export { Flipcard, Front, Back }








// const flip = () => {
//     console.log(inner.current.style.transform)
// }
// const eventListener = useCallback(() => {
//     if (showingFront) {
//         backDiv.current.style.display = "none";
//     }
//     else {
//         frontDiv.current.style.display = "none";
//     }
// }, [showingFront])

// useEffect(() => {
//     inner.current.addEventListener('transitionend', eventListener);
//     return () => inner.current.removeEventListener('transitionend', eventListener)
// }, [eventListener])

// flip()
// if (showingFront) {
//     backDiv.current.style.display = "block";
//     inner.current.style.transform = "rotateY(540deg)"
// }
// else {
//     frontDiv.current.style.display = "block";
//     inner.current.style.transform = "rotateY(0deg)";

// }
// setShowingFront(!showingFront)