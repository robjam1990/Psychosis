from collections import defaultdict

class EventTarget:
    pass  # Placeholder for EventTarget functionality

class Observation:
    event_emitter = EventTarget()
    encyclopedia = defaultdict(dict)

    @classmethod
    def record(cls, observation_name, action_properties, participant):
        if not isinstance(observation_name, str) or not action_properties or not isinstance(action_properties, dict):
            print('Invalid input parameters for recording observation.')
            return

        try:
            cls.encyclopedia[observation_name] = action_properties
            observation_event = {'observationName': observation_name, 'actionProperties': action_properties}
            cls.event_emitter.dispatch_event('observation', observation_event)
        except Exception as e:
            print('Error recording observation:', e)

def handle_observation_event(event):
    observation_name = event['observationName']
    action_properties = event['actionProperties']
    print(f"New observation recorded: {observation_name}", action_properties)

# Add listener for the 'observation' event
Observation.event_emitter.add_event_listener('observation', handle_observation_event)
