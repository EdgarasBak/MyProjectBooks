import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ReservationList = () => {
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchReservations = async () => {
            try {
                const response = await axios.get('https://localhost:7284/api/reservation/GetAllReservations');
                setReservations(response.data);
            } catch (error) {
                console.error('Error fetching reservations:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchReservations();
    }, []);

    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div className="container mt-5">
            <h2>My Reservations</h2>
            <table className="table table-striped mt-3">
                <thead>
                    <tr>
                        <th>Book Name</th>
                        <th>Days</th>
                        <th>Quick Pickup</th>
                        <th>Total Cost</th>
                    </tr>
                </thead>
                <tbody>
                    {reservations.map(reservation => (
                        <tr key={reservation.id}>
                            <td>{reservation.bookName}</td>
                            <td>{reservation.days}</td>
                            <td>{reservation.quickPickUp ? 'Yes' : 'No'}</td>
                            <td>€{reservation.totalCost}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ReservationList;