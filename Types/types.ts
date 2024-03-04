// File = robjam1990/Psychosis/Types/types.ts

// Import Dispatch type from Redux
import { Dispatch } from 'redux';

// Define specific payload interfaces for different types of actions
interface MovePayload {
    // Define properties specific to move actions
}

interface ChatPayload {
    // Define properties specific to chat actions
}

// Define ActivePlayersArg type with proper typing
type ActivePlayersArg = {
    [playerID: string]: string | null | undefined;
};

// Define ActionShape interface with proper typing and documentation
interface ActionShape<T> {
    type: string;
    payload: T;
    playerID?: PlayerID;
    // Add detailed documentation for other properties as well
}

// Define CredentialedActionShape interface extending ActionShape
interface CredentialedActionShape<T> extends ActionShape<T> {
    credentials: string;
}

// Define FilteredMetadata interface with placeholder properties
interface FilteredMetadata {
    // Add properties as needed and provide documentation
}

// Define Game interface with placeholder properties
interface Game {
    // Add properties as needed and provide documentation
}

// Define LogEntry interface with placeholder properties
interface LogEntry {
    // Add properties as needed and provide documentation
}

// Define Reducer type with proper typing
type Reducer<S, A> = (state: S, action: A) => S;

// Define State interface with placeholder properties
interface State {
    // Add properties as needed and provide documentation
}

// Define ChatMessage interface with placeholder properties
interface ChatMessage {
    // Add properties as needed and provide documentation
}

// Define ActionError interface with proper typing and documentation
interface ActionError {
    code: number; // Placeholder for error code
    message: string; // Placeholder for error message
    // Add more properties as needed and provide documentation
}

// Define TransientMetadata interface with placeholder properties
interface TransientMetadata {
    // Add properties as needed and provide documentation
}

// Define ActionResult interface with placeholder properties
interface ActionResult {
    // Add properties as needed and provide documentation
}

// Define TransientState interface extending State with placeholder properties
interface TransientState<G extends any = any> extends State<G> {
    // Define transient state properties
    transientProperty: any; // Placeholder for transient property
}

// Define PluginState interface with placeholder properties
interface PluginState {
    // Add properties as needed and provide documentation
}

// Define PluginContext interface with placeholder properties
interface PluginContext<API extends any = any, Data extends any = any, G extends any = any> {
    // Add properties as needed and provide documentation
}

// Define Plugin interface with placeholder properties
interface Plugin<API extends any = any, Data extends any = any, G extends any = any> {
    // Add properties as needed and provide documentation
}

// Define Ctx interface with placeholder properties
interface Ctx {
    // Add properties as needed and provide documentation
}

// Define DefaultPluginAPIs interface with placeholder properties
interface DefaultPluginAPIs {
    // Add properties as needed and provide documentation
}

// Define Game interface with placeholder properties and documentation
export interface Game<G extends any = any, PluginAPIs extends Record<string, unknown> = Record<string, unknown>, SetupData extends any = any> {
    // Define the game itself
    setup: (ctx: Ctx, setupData: SetupData) => G; // Placeholder for game setup function
    moves: Record<string, (G: G, ctx: Ctx, ...args: any[]) => G>; // Placeholder for game moves
}

// Define Server namespace with placeholder types
export namespace Server {
    // Define types related to the server
    // Add types as needed and provide documentation
}

// Define LobbyAPI namespace with placeholder types
export namespace LobbyAPI {
    // Define types related to the lobby
    // Add types as needed and provide documentation
}

// Define ActionShape namespace with placeholder types
export namespace ActionShape {
    // Define shapes of actions
    // Add types as needed and provide documentation
}

// Define ActionPayload namespace with placeholder types
export namespace ActionPayload {
    // Define payloads for actions
    // Add types as needed and provide documentation
}

// Define SyncInfo interface with placeholder properties
export interface SyncInfo {
    // Add properties as needed and provide documentation
}

// Define ChatMessage interface with placeholder properties
export interface ChatMessage {
    // Define a message in the chat
    // Add properties as needed and provide documentation
}
