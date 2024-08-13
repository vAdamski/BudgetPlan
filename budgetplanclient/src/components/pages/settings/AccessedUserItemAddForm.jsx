import {useState} from "react";

function AccessedUserItemAddForm({handleAddAccessedUser})
{
    const [userEmail, setUserEmail] = useState('')

    const handleAddAccessedUserForm = (e) => {
        e.preventDefault();
        handleAddAccessedUser(userEmail);
        setUserEmail
    }

    return (
        <form onSubmit={handleAddAccessedUserForm}>
            <div className={'input-group input-group-sm'}>
                <input type="text" className="form-control" value={userEmail}
                       onChange={(e) => setUserEmail(e.target.value)}/>
                <button className="btn btn-outline-success" type="submit">+</button>
            </div>
        </form>
    );
}

export default AccessedUserItemAddForm;