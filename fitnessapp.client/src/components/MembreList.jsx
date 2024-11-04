// File: fitnessapp.client/src/components/MembreList.jsx
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const MembreList = () => {
    const [membres, setMembres] = useState([]);

    useEffect(() => {
        axios.get('/api/membres')
            .then(response => {
                setMembres(response.data);
            })
            .catch(error => {
                console.error('There was an error fetching the membres!', error);
            });
    }, []);

    return (
        <div>
            <h2>Membres</h2>
            <ul>
                {membres.map(membre => (
                    <li key={membre.membreId}>{membre.membreFirstname} {membre.membreLastname}</li>
                ))}
            </ul>
        </div>
    );
};

export default MembreList;
