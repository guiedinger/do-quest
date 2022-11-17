import { useContext } from "react";
import UserContext from "../contexts/User";

export default function useUser() {
  const context = useContext(UserContext);
  return context;
}
