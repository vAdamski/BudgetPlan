import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import {useEffect, useState} from "react";
import AccessedUserItem from "./AccessedUserItem.jsx";
import AccessedUserItemAddForm from "./AccessedUserItemAddForm.jsx";
import useAccessesApi from "../../../services/api/accessesApi.jsx";

function AccessedUsersCard({budgetPlanId}) {
    const {getBudgetPlanAccessesForBudgetPlan} = useBudgetPlansApi();
    const {addUserToAccess, removeUserFromAccess} = useAccessesApi();

    const [usersList, setUsersList] = useState([]);
    const [accessId, setAccessId] = useState(null);
    const [handleUpdate, setHandleUpdate] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getBudgetPlanAccessesForBudgetPlan(budgetPlanId);
            setUsersList(response.accessedItems);
            setAccessId(response.accessId);
        }

        fetchData();
    }, [budgetPlanId, handleUpdate]);

    const handleAddAccessedUser = async (userEmail) => {
        await addUserToAccess(accessId, userEmail);

        setHandleUpdate(!handleUpdate);
    }

    const handleRemoveAccessedUser = async (userEmail) => {
        await removeUserFromAccess(accessId, userEmail);

        setHandleUpdate(!handleUpdate);
    }

    return (
        <div className={'card'}>
            <div className={'card-header text-center'}>
                <h4>
                    Dostępy użytkowników
                </h4>
            </div>
            <div className={'card-body'}>
                <ul className={'list-group'}>
                    {usersList.map((user, index) => (
                        <AccessedUserItem key={index} accessedUser={user} onRemoveAccessedUser={handleRemoveAccessedUser}/>
                    ))}
                    <AccessedUserItemAddForm handleAddAccessedUser={handleAddAccessedUser}/>
                </ul>
            </div>
        </div>
    );
}

export default AccessedUsersCard;