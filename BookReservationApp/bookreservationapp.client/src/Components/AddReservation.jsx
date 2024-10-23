import React from 'react';
import { useLocation } from 'react-router-dom';
import axios from 'axios';
import ReservationForm from './ReservationForm'; 
const AddReservation = () => {
    const { state } = useLocation();

    const handleSubmit = async (reservation) => {
        console.log('Submitting to backend:', reservation); 

        try {
            const response = await axios.post('https://localhost:7284/api/reservation/AddReservation', reservation);
            if (response.data && response.data.totalCost !== undefined) {
                alert(`Reservation added successfully! Total Cost: €${response.data.totalCost.toFixed(2)}`);
            } else {
                console.error('Total cost not returned in response:', response.data);
            }
        } catch (error) {
            console.error('Error adding reservation:', error);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Reserve {state.book.name}</h2>
            <ReservationForm onSubmit={handleSubmit} book={state.book} />
        </div>
    );
};

export default AddReservation;

