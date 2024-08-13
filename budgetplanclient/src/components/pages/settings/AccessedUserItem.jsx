function AccessedUserItem({accessedUser, key, onRemoveAccessedUser}) {
    return (
        <li key={key}>
            <div className="d-flex align-items-center justify-content-between mb-1">
                {accessedUser.email}
                <span className="material-symbols-outlined" style={{
                    'font-size': '1.5rem',
                    'color': 'red',
                    'cursor': 'pointer',
                }} onClick={() => onRemoveAccessedUser(accessedUser.email)}>delete_forever</span>
            </div>
        </li>
    );
}

export default AccessedUserItem;