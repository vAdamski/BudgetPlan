import {useContext} from 'react';
import {AuthContext} from './AuthProvider';

const HomePage = () => {
    const {user, login, logout} = useContext(AuthContext);

    return (
        <div>
            <h1>Home Page</h1>
            {
                user ? (
                <div>
                    <p>Welcome, {user.profile.name}</p>
                    <p>Welcome, {user.access_token}</p>
                    <button onClick={logout}>Logout</button>
                </div>
            ) : (
                <button onClick={login}>Login</button>
            )}
        </div>
    );
};

HomePage.propTypes = {
    // Dodaj tutaj walidację prop-types, jeśli HomePage przyjmuje props
};

export default HomePage;