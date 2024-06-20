import './SideNavigationBar.css';
import {useContext} from "react";
import {AuthContext} from "../../services/authProvider.jsx";

function UserProfileInfoListItem() {
    const {user} = useContext(AuthContext);

    let userName = user.profile.name ?? '';

    return (
        <div className={'navbar-item-profile'}>
            <a>Welcome {userName}!</a>
        </div>
    );
}

export default UserProfileInfoListItem;